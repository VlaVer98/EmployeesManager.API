import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DataTablesModule } from "angular-datatables";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AboutCompanyComponent } from './about-company/about-company.component';
import { EmployeeTableComponent } from './employee-table/employee-table.component';
import { EmployeeCreateFormComponent } from './employee-create-form/employee-create-form.component';
import { EmployeeUpdateFormComponent } from './employee-update-form/employee-update-form.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        AboutCompanyComponent,
        EmployeeTableComponent,
        EmployeeCreateFormComponent,
        EmployeeUpdateFormComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        DataTablesModule,
        NgbModule,
        RouterModule.forRoot([
            { path: '', component: AboutCompanyComponent, pathMatch: 'full' },
            { path: 'about-company', component: AboutCompanyComponent },
            { path: 'employee-table', component: EmployeeTableComponent },
        ])
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
    constructor() {
        this.overrideDate();
    }

    overrideDate() {
        Date.prototype.toJSON = function (key) {
            console.log(this.toISOString())
            return this.toISOString();
        }

    }
}
