import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IPolicy } from '../models/IPolicy';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-policy-list',
  template: `
    <table mat-table [dataSource]="policies$" class="mat-elevation-z4">
      <ng-container matColumnDef="code">
        <th mat-header-cell *matHeaderCellDef> Code </th>
        <td mat-cell *matCellDef="let policy"> {{policy.code}} </td>
      </ng-container>
      <ng-container matColumnDef="name">
        <th mat-header-cell *matHeaderCellDef> Name </th>
        <td mat-cell *matCellDef="let policy"> {{policy.name}} </td>
      </ng-container>
      <ng-container matColumnDef="policyNumber">
        <th mat-header-cell *matHeaderCellDef> Policy Number </th>
        <td mat-cell *matCellDef="let policy"> {{policy.policyNumber}} </td>
      </ng-container>

      <tr mat-header-row *matHeaderRowDef="columns"></tr>
      <tr mat-row *matRowDef="let row; columns: columns;" [routerLink]="[row.id]"></tr>
    </table>
  `,
  styleUrls: ['./policy-list.component.scss']
})
export class PolicyListComponent implements OnInit {
  policies$ = this.http.get<IPolicy[]>('https://localhost:5001/api/policies').pipe(
    map(policies => policies.map(p => ({
      ...p,
      dateStart: new Date(p.dateStart),
      dateEnd: new Date(p.dateEnd)
    })))
  );

  columns = ['code', 'name', 'policyNumber'];

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit(): void {
  }

}
