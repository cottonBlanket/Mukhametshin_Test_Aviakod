import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { AuthProvider, useAuth } from "./context/AuthContext";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import HomePage from "./pages/HomePage";
import {ReactJSX} from "@emotion/react/dist/declarations/src/jsx-namespace";

function PrivateRoute({ children }: { children: ReactJSX.Element }) {
  const { token } = useAuth();
  return token ? children : <Navigate to="/login" />;
}

export default function App() {
  return (
      <AuthProvider>
        <BrowserRouter>
          <Routes>
            <Route path="/login" element={<LoginPage />} />
            <Route path="/register" element={<RegisterPage />} />
            <Route path="/" element={<PrivateRoute><HomePage /></PrivateRoute>} />
          </Routes>
        </BrowserRouter>
      </AuthProvider>
  );
}
