import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Digital Express';

  // inject into a angular component
  constructor() {}

  ngOnInit(): void {
  }
}
