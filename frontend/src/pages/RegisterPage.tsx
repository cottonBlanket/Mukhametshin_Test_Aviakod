import { useState } from "react";
import { useAuth } from "../context/AuthContext";
import { Button, TextField, Box, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function RegisterPage() {
    const { registerUser } = useAuth();
    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [success, setSuccess] = useState("");
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async () => {
        try {
            await registerUser(userName, password);
            setSuccess("Регистрация прошла успешно. Сейчас переходим на страницу входа...");
            setError("");
            setTimeout(() => navigate("/login"), 2000); 
        } catch {
            setError("Ошибка регистрации");
        }
    };

    return (
        <Box sx={{ maxWidth: 400, mx: "auto", mt: 6 }}>
            <Typography variant="h5" gutterBottom>
                Регистрация
            </Typography>
            {success && <Typography color="primary">{success}</Typography>}
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
                Зарегистрироваться
            </Button>
        </Box>
    );
}
