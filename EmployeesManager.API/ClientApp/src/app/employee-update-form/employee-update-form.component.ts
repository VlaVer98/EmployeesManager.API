import { Component, Injectable, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { TodosService } from '../Services/employee.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from '../models/employee.model';

@Component({
    selector: 'app-employee-update-form',
    templateUrl: './employee-update-form.component.html'
})

@Injectable({ providedIn: 'root' })
export class EmployeeUpdateFormComponent implements OnInit {
    public todosService: TodosService;
    public modalService: NgbModal
    public dtTrigger: Subject<any> = new Subject<any>();

    public employee: Employee;

    constructor(todosService: TodosService, modalService: NgbModal) {
        this.todosService = todosService;
        this.modalService = modalService;
    }

    ngOnInit() {
    }

    open(update, employee: Employee, callback: () => void) {
        this.employee = employee;
        console.log(update);
        
        this.modalService.open(update, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
            this.todosService.update(this.employee, callback);
        }, (reason) => {
            
        });
    }
}