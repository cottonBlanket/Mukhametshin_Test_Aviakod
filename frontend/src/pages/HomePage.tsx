import { useAuth } from "../context/AuthContext";
import TaskBoard from "../components/TaskBoard";
import { Button, Box } from "@mui/material";

export default function HomePage() {
    const { logout } = useAuth();

    return (
        <Box>
            <Button onClick={logout} sx={{ m: 2 }}>
                Выйти
            </Button>
            <TaskBoard />
        </Box>
    );
}
