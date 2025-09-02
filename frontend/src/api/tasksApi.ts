import { IssueDto, IssueUpdateDto } from "../types";

const ISSUES_URL = `http://localhost:8080/api/issues`;

function authHeaders(): HeadersInit {
    const token = localStorage.getItem("token");
    const headers: Record<string, string> = {
        "Content-Type": "application/json",
    };
    if (token) headers["Authorization"] = `Bearer ${token}`;
    return headers;
}

async function fetchJson<T>(url: string, options?: RequestInit): Promise<T> {
    const res = await fetch(url, options);
    const text = await res.text();

    if (!res.ok) {
        const data = JSON.parse(text);
        throw {general: data["Error"] || `Ошибка запроса: ${res.status}`}
    }

    if (!text) return {} as T;
    return JSON.parse(text);
}




export async function getTasks() {
    return fetchJson<IssueDto[]>(ISSUES_URL, { headers: authHeaders() });
}

export async function addTask(task: { title: string; description?: string }) {
    return fetchJson<IssueDto>(ISSUES_URL, {
        method: "POST",
        headers: authHeaders(),
        body: JSON.stringify(task),
    });
}

export async function updateTask(task: IssueUpdateDto) {
    return fetchJson<void>(`${ISSUES_URL}`, {
        method: "PATCH",
        headers: authHeaders(),
        body: JSON.stringify(task),
    });
}

export async function deleteTask(id: string) {
    return fetchJson<void>(`${ISSUES_URL}/${id}`, {
        method: "DELETE",
        headers: authHeaders(),
    });
}
