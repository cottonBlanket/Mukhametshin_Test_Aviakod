export type TaskStatus = "Новая" | "В процессе" | "Выполнено";
export enum IssueStatus {
    New = "New",
    InProgress = "InProgress",
    Done = "Done",
}

export interface IssueCreateDto {
    title: string;
    description: string;
}

export interface IssueUpdateDto {
    id: string;
    title?: string;
    description?: string;
    status?: IssueStatus;
}

export interface IssueDto {
    id: string;
    title: string;
    description: string;
    status: IssueStatus;
    added: string;    
    modified: string; 
}

export interface IssueFindDto {
    skip?: number;
    take?: number;
    search?: string;
    status?: IssueStatus;
}
