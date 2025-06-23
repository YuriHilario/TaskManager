import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TaskService } from '../../../../services/taskservices/taskservice';

@Component({
  selector: 'app-update-task',
  standalone: true,
  imports: [FormsModule, CommonModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule],
  templateUrl: './updatetask.html',
  styleUrls: ['./updatetask.css']
})
export class UpdateTask implements OnInit {
  taskService = inject(TaskService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  id!: number;
  title = '';
  description = '';
  priority = 0;
  status = 0;
  errorMessage = '';

  ngOnInit() {
    this.id = +this.route.snapshot.paramMap.get('id')!;
    this.taskService.getTask(this.id).subscribe(task => {
      this.title = task.title;
      this.description = task.description ?? '';
      this.priority = task.priority;
      this.status = task.status;
    });
  }

  onUpdate() {
    const updatedTask = {
      id: this.id,
      title: this.title,
      description: this.description,
      priority: this.priority,
      status: this.status
    };

    this.taskService.updateTask(this.id, updatedTask).subscribe({
      next: () => {
        this.router.navigate(['home/tasks']);
      },
      error: () => {
        this.errorMessage = 'Error updating task.';
      }
    });
  }
}
