import { IssueDto, IssueUpdateDto, IssueStatus } from "../types";
import { Button, Card, CardContent, Typography, Stack, MenuItem, Select } from "@mui/material";
import { SelectChangeEvent } from "@mui/material";

interface Props {
    task: IssueDto;
    onUpdate: (task: IssueUpdateDto) => void;
    onDelete: (id: string) => void;
}

export default function TaskItem({ task, onUpdate, onDelete }: Props) {
    const handleStatusChange = (e: SelectChangeEvent<IssueStatus>) => {
        onUpdate({ id: task.id, status: e.target.value as IssueStatus });
    };

    return (
        <Card sx={{ mb: 2 }}>
            <CardContent>
                <Typography variant="h6">{task.title}</Typography>
                {task.description && (
                    <Typography variant="body2" color="text.secondary">
                        {task.description}
                    </Typography>
                )}
                <Typography variant="body1" sx={{ mt: 1 }}>
                    Статус:
                    <Select
                        value={task.status}
                        onChange={handleStatusChange}
                        size="small"
                        sx={{ ml: 1 }}
                    >
                        <MenuItem value={IssueStatus.New}>Новая</MenuItem>
                        <MenuItem value={IssueStatus.InProgress}>В процессе</MenuItem>
                        <MenuItem value={IssueStatus.Done}>Выполнено</MenuItem>
                    </Select>
                </Typography>
                <Stack direction="row" spacing={1} sx={{ mt: 2 }}>
                    <Button variant="contained" color="error" onClick={() => onDelete(task.id)}>
                        Удалить
                    </Button>
                </Stack>
            </CardContent>
        </Card>
    );
}
