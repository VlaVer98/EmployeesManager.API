import { AfterViewInit, Component, Inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { EmployeeCreateFormComponent } from '../employee-create-form/employee-create-form.component';
import { EmployeeUpdateFormComponent } from '../employee-update-form/employee-update-form.component';
import { TodosService } from '../Services/employee.service';

@Component({
    selector: 'app-employee-table',
    templateUrl: './employee-table.component.html'
})

export class EmployeeTableComponent implements AfterViewInit, OnDestroy, OnInit {
    public todosService: TodosService;
    public employeeUpdateFormComponent: EmployeeUpdateFormComponent;
    public employeeCreateFormComponent: EmployeeCreateFormComponent;

    @ViewChild(DataTableDirective, { static: false })
    public dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject<any>();

    constructor(todosService: TodosService,
        employeeUpdateFormComponent: EmployeeUpdateFormComponent,
        employeeCreateFormComponent: EmployeeCreateFormComponent) {
        this.todosService = todosService;
        this.employeeUpdateFormComponent = employeeUpdateFormComponent;
        this.employeeCreateFormComponent = employeeCreateFormComponent;
    }

    ngOnInit() {
        var updateTableCallback = (): void => {
            this.rerender()
        }

        this.todosService.fetchTodos(updateTableCallback);
    }

    ngAfterViewInit(): void {
        this.dtTrigger.next();
    }

    ngOnDestroy(): void {
        // Do not forget to unsubscribe the event
        this.dtTrigger.unsubscribe();
    }

    rerender(): void {
        this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
            // Destroy the table first
            dtInstance.destroy();
            // Call the dtTrigger to rerender again
            this.dtTrigger.next();
        });
    }

    confirmDelete(id: string): void{
        if(confirm('Are you sure you want to delete this?')) {
            this.todosService.delete(id, this.rerenderCallback);
        }
    }

    rerenderCallback = (): void => {
        this.rerender();
    }
}