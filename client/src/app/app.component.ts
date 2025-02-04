import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {

  http = inject(HttpClient);
  title = 'Meet your sport buddies';
  users: any;
  usersFiltred:any;

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: (response) => (this.users = response),
      error: (error) => console.error(error),
      complete: () => console.log('Request has completed'),
    });
  }

  onClick() {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: (response) => {
        const res = response as any[];
        console.log(res);
        this.usersFiltred = res.filter(e => e.userName.startsWith('s') || e.userName.startsWith('A'));
      },
      error: (error) => console.error(error),
      complete: () => console.log('Request has completed'),
    });
  }

}
