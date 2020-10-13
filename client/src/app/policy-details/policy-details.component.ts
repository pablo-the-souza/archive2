import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { IPolicy } from '../models/IPolicy';

@Component({
  selector: 'app-policy-details',
  template: `
  <form [formGroup]="form" (ngSubmit)="savePolicy()">
    <div class="example-container">
      <mat-form-field appearance="standard">
        <mat-label>Code</mat-label>
        <input matInput formControlName="code">
      </mat-form-field>
      <br>
      <mat-form-field appearance="standard">
        <mat-label>Name</mat-label>
        <input matInput formControlName="name">
      </mat-form-field>
      <br>
      <mat-form-field appearance="standard">
        <mat-label>Policy Number</mat-label>
        <input matInput formControlName="policyNumber">
      </mat-form-field>
    </div>
    <button type="submit" mat-flat-button color="primary">Save</button>
  </form>
  <pre>{{ box | json  }}</pre>
  `,
  styleUrls: ['./policy-details.component.scss']
})
export class PolicyDetailsComponent implements OnInit, OnDestroy {
  private _destroy$ = new Subject<void>();

  policyId: string = this.route.snapshot.params.id;
  box: any;

  form = this.createForm();

  policy$ = this.http.get<IPolicy>(`https://localhost:5001/api/policies/${this.policyId}`);

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.policy$
      .pipe(takeUntil(this._destroy$))
      .subscribe(policy => this.setValueToForm(policy));
  }

  ngOnDestroy(): void {
    this._destroy$.next();
  }

  private createForm(): FormGroup {
    return this.fb.group({
      id: [null],
      code: [null, Validators.required],
      name: [null, Validators.required],
      policyNumber: [null, Validators.required]
    });
  }

  private setValueToForm(policy: IPolicy): void {
    this.form.patchValue(policy);
    this.box = policy.box;
  }

  savePolicy(): void {
    debugger;
    if (this.form.invalid) return;
    const policy = this.form.value as IPolicy;
    this.http.put(`https://localhost:5001/api/policies/${this.policyId}`, policy);
  }
}
