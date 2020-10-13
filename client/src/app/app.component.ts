import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPolicy } from './models/IPolicy';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  code: string;
  name: string;
  policyType: string;
  policyNumber: string;
  dateStart: string;
  dateEnd: string;
  comments: string;
  boxId: number;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/policies').subscribe((response: IPolicy) => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
}
