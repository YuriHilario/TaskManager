// src/app/services/task.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface TaskItem {
  id: number;
  title: string;
  description?: string;
  priority: number;
  status: number;
  dateCreation: string;
}

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'https://localhost:7115/api/TaskItem';

  constructor(private http: HttpClient) {}

  getTask(id: number) {
  return this.http.get<TaskItem>(`${this.apiUrl}/${id}`);
  }

  getTasks(): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(this.apiUrl);
  }

  createTask(task: Partial<TaskItem>) {
    return this.http.post(this.apiUrl, task);
  }

  updateTask(id: number, task: Partial<TaskItem>) {
    return this.http.put(`${this.apiUrl}/${id}`, task);
  }

  deleteTask(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
