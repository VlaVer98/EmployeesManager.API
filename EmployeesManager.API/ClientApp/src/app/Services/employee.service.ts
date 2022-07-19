import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee.model';
import { DatePipe } from '@angular/common';

interface Wrapper<T> {
    result: T,
    isSuccessful: boolean;
    errors: string[];
    message: string;
}

@Injectable({ providedIn: 'root' })
export class TodosService {
    private _baseUrl: string;
    public employees: Employee[] = [];

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }

    fetchTodos(callback: () => void) {
        this.http.get<Wrapper<Employee[]>>(this._baseUrl + 'api/Employee').subscribe(result => {
            if (result.isSuccessful) {
                this.employees = result.result;
            }
            callback();
        }, error => console.error(error));
    }

    create(employee: Employee, callback: () => void) {
        console.log(employee);

        this.http.post<Wrapper<Employee>>(this._baseUrl + 'api/Employee', employee).subscribe(result => {
            if (result.isSuccessful) {
                this.employees.push(result.result);
                callback();
            }
        }, error => console.error(error));
    }

    update(employee: Employee, callback: () => void) {
        this.http.put<Wrapper<Employee>>(this._baseUrl + 'api/Employee', employee).subscribe(result => {
            if (result.isSuccessful) {
                this.employees = this.employees.filter(t => t.id !== result.result.id);
                this.employees.push(result.result);
            }
            callback();
        }, error => console.error(error));
    }

    delete(id: string, callback: () => void) {
        this.http.delete<Wrapper<Employee>>(this._baseUrl + 'api/Employee/' + id, {}).subscribe(result => {
            if (result.isSuccessful) {
                this.employees = this.employees.filter(t => t.id !== id)
            }
            callback();
        }, error => console.error(error));
    }
}