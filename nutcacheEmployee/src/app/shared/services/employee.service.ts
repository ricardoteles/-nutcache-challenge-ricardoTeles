import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';

@Injectable()
export class EmployeeService {
    host = "https://localhost:7086/api/v1/employees";

    constructor(private http: HttpClient) { }

    getEmployees(): Observable<Employee[]> {
        return this.http.get<Employee[]>(`${this.host}`);
    }

    getEmployee(id: number): Observable<Employee> {
        return this.http.get<Employee>(`${this.host}/${id}`);
    }

    postEmployees(payload: Employee): Observable<Employee> {
        return this.http.post<Employee>(
        `${this.host}`, payload);
    }

    putEmployees(id: number, payload: Employee): Observable<Employee> {
        return this.http.put<Employee>(
        `${this.host}/${id}`, payload);
    }

    deleteEmployee(id: number): Observable<Employee> {
        return this.http.delete<Employee>(`${this.host}/${id}`);
    }
}
