import { useState } from "react";
import { useAuth } from "../context/AuthContext";
import { Button, TextField, Box, Typography, Link } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function LoginPage() {
    const { loginUser } = useAuth();
    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async () => {
        try {
            await loginUser(userName, password);
            navigate("/");
        } catch {
            setError("Неверный логин или пароль");
        }
    };

    return (
        <Box sx={{ maxWidth: 400, mx: "auto", mt: 6 }}>
            <Typography variant="h5" gutterBottom>
                Вход
            </Typography>
            {error && <Typography color="error">{error}</Typography>}
            <TextField
                fullWidth
                label="Логин"
                margin="normal"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
            />
            <TextField
                fullWidth
                label="Пароль"
                type="password"
                margin="normal"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <Button variant="contained" fullWidth sx={{ mt: 2 }} onClick={handleSubmit}>
                Войти
            </Button>

            {/* Ссылка на регистрацию */}
            <Typography sx={{ mt: 2 }} align="center">
                Нет аккаунта?{" "}
                <Link component="button" variant="body2" onClick={() => navigate("/register")}>
                    Зарегистрироваться
                </Link>
            </Typography>
        </Box>
    );
}
