import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

import { TaskService } from '../../../../services/taskservices/taskservice';
@Component({
  selector: 'app-create-task',
  standalone: true,
  imports: [FormsModule, CommonModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule],
  templateUrl: './createtask.html',
  styleUrls: ['./createtask.css']
})
export class CreateTask {
  title = '';
  description = '';
  priority = 0;
  status = 0;
  errorMessage = '';

  constructor(private taskService: TaskService, private router: Router) {}

  onCreate() {
    const newTask = {
      title: this.title,
      description: this.description,
      priority: this.priority,
      status: this.status
    };

    this.taskService.createTask(newTask).subscribe({
      next: () => {
        this.router.navigate(['home/tasks']);
      },
      error: () => {
        this.errorMessage = 'Error creating task.';
      }
    });
  }
}
