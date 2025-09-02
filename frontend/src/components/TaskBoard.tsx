import { useEffect, useState, useCallback } from "react";
import { IssueDto, IssueCreateDto, IssueUpdateDto, IssueStatus } from "../types";
import { getTasks, addTask, updateTask, deleteTask } from "../api/tasksApi";
import TaskItem from "./TaskItem";
import {
    Box,
    Typography,
    Button,
    Stack,
    Modal,
    TextField,
    Divider,
} from "@mui/material";

export default function TaskBoard() {
    const [tasks, setTasks] = useState<IssueDto[]>([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [newTitle, setNewTitle] = useState("");
    const [newDescription, setNewDescription] = useState("");
    const [errorMessage, setErrorMessage] = useState<string | null>(null); 

    const loadTasks = useCallback(async () => {
        try {
            const data = await getTasks();
            setTasks(data);
        } catch (err) {
            console.error(err);
        }
    }, []);

    useEffect(() => {
        loadTasks();
    }, [loadTasks]);

    const handleAdd = useCallback(async () => {
        if (!newTitle.trim()) return;

        const newTask: IssueCreateDto = { title: newTitle, description: newDescription };

        try {
            await addTask(newTask);
            setNewTitle("");
            setNewDescription("");
            setErrorMessage(null);
            setIsModalOpen(false);
            await loadTasks();
        } catch (err: any) {
            setErrorMessage(err.general || "Неизвестная ошибка");
        }
    }, [newTitle, newDescription, loadTasks]);

    const handleUpdate = useCallback(async (update: IssueUpdateDto) => {
        try {
            await updateTask(update);
            await loadTasks();
        } catch (err) {
            console.error(err);
        }
    }, [loadTasks]);

    const handleDelete = useCallback(async (id: string) => {
        try {
            await deleteTask(id);
            await loadTasks();
        } catch (err) {
            console.error(err);
        }
    }, [loadTasks]);

    const handleOpenModal = () => {
        setIsModalOpen(true);
        setErrorMessage(null);
        setNewTitle("");
        setNewDescription("");
    };

    const tasksByStatus = {
        [IssueStatus.New]: tasks.filter(t => t.status === IssueStatus.New),
        [IssueStatus.InProgress]: tasks.filter(t => t.status === IssueStatus.InProgress),
        [IssueStatus.Done]: tasks.filter(t => t.status === IssueStatus.Done),
    };

    const columns = [
        { status: IssueStatus.New, label: "Новые" },
        { status: IssueStatus.InProgress, label: "В процессе" },
        { status: IssueStatus.Done, label: "Выполненные" },
    ];

    return (
        <Box sx={{ maxWidth: 1200, mx: "auto", mt: 4 }}>
            <Stack direction="row" justifyContent="space-between" mb={3}>
                <Typography variant="h4">Доска задач</Typography>
                <Button variant="contained" onClick={handleOpenModal}>
                    Создать задачу
                </Button>
            </Stack>

            <Stack direction="row" spacing={2} sx={{ minHeight: "400px" }}>
                {columns.map((col) => (
                    <Box
                        key={col.status}
                        sx={{
                            flex: 1,
                            bgcolor: "background.paper",
                            p: 2,
                            borderRadius: 2,
                            display: "flex",
                            flexDirection: "column",
                        }}
                    >
                        <Typography variant="h6" mb={2} align="center">
                            {col.label}
                        </Typography>
                        <Divider sx={{ mb: 2 }} />
                        <Stack spacing={1} flexGrow={1}>
                            {tasksByStatus[col.status].length > 0 ? (
                                tasksByStatus[col.status].map(task => (
                                    <TaskItem
                                        key={task.id}
                                        task={task}
                                        onUpdate={handleUpdate}
                                        onDelete={handleDelete}
                                    />
                                ))
                            ) : (
                                <Typography
                                    variant="body2"
                                    color="text.secondary"
                                    align="center"
                                    sx={{ mt: 2 }}
                                >
                                    Нет задач
                                </Typography>
                            )}
                        </Stack>
                    </Box>
                ))}
            </Stack>

            <Modal open={isModalOpen} onClose={() => setIsModalOpen(false)}>
                <Box
                    sx={{
                        position: "absolute",
                        top: "50%",
                        left: "50%",
                        transform: "translate(-50%, -50%)",
                        bgcolor: "background.paper",
                        p: 4,
                        width: 400,
                        borderRadius: 2,
                    }}
                >
                    <Typography variant="h6" mb={2}>
                        Создать новую задачу
                    </Typography>

                    <TextField
                        label="Название"
                        value={newTitle}
                        onChange={(e) => setNewTitle(e.target.value)}
                        fullWidth
                        sx={{ mb: 1 }}
                    />

                    <TextField
                        label="Описание"
                        value={newDescription}
                        onChange={(e) => setNewDescription(e.target.value)}
                        fullWidth
                        multiline
                        rows={3}
                        sx={{ mb: 1 }}
                    />

                    {errorMessage && (
                        <Typography color="error" variant="body2" sx={{ mb: 1 }}>
                            {errorMessage}
                        </Typography>
                    )}

                    <Stack direction="row" spacing={2} justifyContent="flex-end" mt={2}>
                        <Button variant="outlined" onClick={() => setIsModalOpen(false)}>
                            Отмена
                        </Button>
                        <Button variant="contained" onClick={handleAdd}>
                            Создать
                        </Button>
                    </Stack>
                </Box>
            </Modal>
        </Box>
    );
}
