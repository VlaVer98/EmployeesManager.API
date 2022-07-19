var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { TodosService } from '../Services/employee.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
let EmployeeUpdateFormComponent = class EmployeeUpdateFormComponent {
    constructor(todosService, modalService) {
        this.dtTrigger = new Subject();
        this.todosService = todosService;
        this.modalService = modalService;
    }
    ngOnInit() {
    }
    open(update, employee, callback) {
        this.employee = employee;
        console.log(update);
        this.modalService.open(update, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
            this.todosService.update(this.employee, callback);
        }, (reason) => {
        });
    }
};
EmployeeUpdateFormComponent = __decorate([
    Component({
        selector: 'app-employee-update-form',
        templateUrl: './employee-update-form.component.html'
    }),
    Injectable({ providedIn: 'root' }),
    __metadata("design:paramtypes", [TodosService, NgbModal])
], EmployeeUpdateFormComponent);
export { EmployeeUpdateFormComponent };
//# sourceMappingURL=employee-update-form.component.js.map