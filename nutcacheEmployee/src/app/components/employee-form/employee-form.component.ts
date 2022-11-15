import { Employee } from './../../shared/models/employee.model';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EmployeeService } from 'src/app/shared/services/employee.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  employeeForm: FormGroup;
  title: string;
  teamOptions: any = [
    '',
    'Mobile',
    'Frontend',
    'Backend',
  ];

  constructor(
          @Inject(MAT_DIALOG_DATA) public data: any,
          private employeeService: EmployeeService,
          public dialogRef: MatDialogRef<EmployeeFormComponent>,
          public fb: FormBuilder) { }

  ngOnInit(): void {
    this.reactiveForm();
    this.title = this.data.msg;
  }

  reactiveForm() {
    this.employeeForm = this.fb.group({
      id: [this.data.employee.id?this.data.employee.id:0],
      name: [this.data.employee.name, [Validators.required]],
      birthDate: [this.data.employee.birthDate, [Validators.required]],
      gender: [this.data.employee.gender, [Validators.required]],
      email: [this.data.employee.email, [Validators.required]],
      cpf: [this.data.employee.cpf, [Validators.required]],
      startDate: [this.data.employee.startDate, [Validators.required]],
      team: [this.data.employee.team]
    });
  }

  date(e: { target: { value: string | number | Date; }; }, name: string) {
    var convertDate = new Date(e.target.value).toISOString().substring(0, 10);
    this.employeeForm.get(name)?.setValue(convertDate, {
      onlyself: true,
    });
  }

  submitForm() {
    if(this.data.employee) {
      this.employeeService.putEmployees(this.data.employee.id, this.employeeForm.value).subscribe(resp => {
        this.dialogRef.close({msg:'Employee has been updated successfully!'});
      });
    } else {
      this.employeeService.postEmployees(this.employeeForm.value).subscribe(resp => {
        this.dialogRef.close({msg:'Employee has been added successfully!'});
      });
    }
  }
}
