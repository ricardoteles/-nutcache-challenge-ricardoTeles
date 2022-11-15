import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EmployeeService } from 'src/app/shared/services/employee.service';

@Component({
  selector: 'app-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.css']
})
export class ConfirmModalComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public dialogRef: MatDialogRef<ConfirmModalComponent>,
              private employeeService: EmployeeService) { }

  ngOnInit(): void {
  }

  deleteEmployee() {
    this.employeeService.deleteEmployee(this.data.employee.id).subscribe(resp => {
    });

    this.dialogRef.close({msg:'Employee has been deleted successfully!'});
  }
}
