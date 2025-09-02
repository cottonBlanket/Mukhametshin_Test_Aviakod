import { createContext, useState, useContext, ReactNode } from "react";
import { login, register } from "../api/authApi";

interface AuthContextType {
    token: string | null;
    loginUser: (userName: string, password: string) => Promise<void>;
    registerUser: (userName: string, password: string) => Promise<void>;
    logout: () => void;
}

const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: { children: ReactNode }) {
    const [token, setToken] = useState<string | null>(() => localStorage.getItem("token"));

    const loginUser = async (userName: string, password: string) => {
        const t = await login(userName, password);
        localStorage.setItem("token", t);
        setToken(t);
    };

    const registerUser = async (userName: string, password: string) => {
        await register(userName, password);
    };

    const logout = () => {
        localStorage.removeItem("token");
        setToken(null);
    };

    return (
        <AuthContext.Provider value={{ token, loginUser, registerUser, logout }}>
            {children}
        </AuthContext.Provider>
    );
}

export function useAuth() {
    const ctx = useContext(AuthContext);
    if (!ctx) throw new Error("AuthContext not found");
    return ctx;
}
