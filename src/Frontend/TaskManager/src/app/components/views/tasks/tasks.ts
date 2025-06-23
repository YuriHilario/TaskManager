import { Component, OnInit } from '@angular/core';
import { TaskService, TaskItem } from '../../../services/taskservices/taskservice';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tasks',
  imports: [MatTableModule, MatButtonModule, CommonModule],
  templateUrl: './tasks.html',
  styleUrls: ['./tasks.css']
})
export class Tasks implements OnInit {
  tasks: TaskItem[] = [];
  displayedColumns = ['id', 'title', 'priority', 'status', 'dateCreation', 'actions'];
  isLoading = true;
  errorMessage = '';

  constructor(private taskService: TaskService, private router: Router)  {}

  ngOnInit() {
    this.loadTasks();
  }

  loadTasks() {
    this.isLoading = true;
    this.taskService.getTasks().subscribe({
      next: (data: TaskItem[]) => {
        this.tasks = data;
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'Error loading tasks';
        this.isLoading = false;
      }
    });
  }

  createTask() {
  this.router.navigate(['/home/tasks/create']);
  }

  editTask(id: number) {
    console.log(id);
    this.router.navigate(['home/tasks/edit', id]);
  }

  deleteTask(id: number) {
    if (confirm('Are you sure you want to delete this task?')) {
      this.taskService.deleteTask(id).subscribe(() => {
        this.loadTasks();
      });
    }
  }  
}
