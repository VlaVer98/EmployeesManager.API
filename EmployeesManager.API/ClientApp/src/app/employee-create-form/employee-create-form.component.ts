import { Component, Injectable, OnInit } from '@angular/core';
import { TodosService } from '../Services/employee.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from '../models/employee.model';

@Component({
    selector: 'app-employee-create-form',
    templateUrl: './employee-create-form.component.html'
})

@Injectable({ providedIn: 'root' })
export class EmployeeCreateFormComponent implements OnInit {
    public todosService: TodosService;
    public modalService: NgbModal

    public employee: Employee;

    constructor(todosService: TodosService, modalService: NgbModal) {
        this.todosService = todosService;
        this.modalService = modalService;
    }

    ngOnInit() {
    }

    open(create, callback: () => void) {
        this.employee = {
            birthday: new Date(),
            department: "",
            employmentDate: null,
            firstName: "",
            id: "",
            lastName: "",
            patronymic: "",
            wage: null
        };

        this.modalService.open(create, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
            this.employee.birthday = new Date(`${this.employee.birthday['year']}-${this.employee.birthday['month'].toString().padStart(2, 0)}-${this.employee.birthday['day'].toString().padStart(2, 0)}`);
            this.employee.employmentDate = new Date(`${this.employee.employmentDate['year']}-${this.employee.employmentDate['month'].toString().padStart(2, 0)}-${this.employee.employmentDate['day'].toString().padStart(2, 0)}`);

            this.todosService.create(this.employee, callback);
        }, (reason) => {
            
        });
    }
}