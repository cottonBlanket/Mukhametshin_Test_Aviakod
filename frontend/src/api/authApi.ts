;const AUTH_URL = `http://localhost:8080/api/auth`;

export async function login(userName: string, password: string): Promise<string> {
    const res = await fetch(`${AUTH_URL}/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ userName, password }),
    });

    if (!res.ok) throw new Error("Неверный логин или пароль");
    const data = await res.json();
    localStorage.setItem("token", data.data);
    return data.data;
}

export async function register(userName: string, password: string): Promise<void> {
    const res = await fetch(`${AUTH_URL}/register`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ userName, password }),
    });

    if (!res.ok) throw new Error("Ошибка регистрации");
}
