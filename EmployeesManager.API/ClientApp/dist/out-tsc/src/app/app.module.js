var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DataTablesModule } from "angular-datatables";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AboutCompanyComponent } from './about-company/about-company.component';
import { EmployeeTableComponent } from './employee-table/employee-table.component';
import { EmployeeCreateFormComponent } from './employee-create-form/employee-create-form.component';
import { EmployeeUpdateFormComponent } from './employee-update-form/employee-update-form.component';
let AppModule = class AppModule {
    constructor() {
        this.overrideDate();
    }
    overrideDate() {
        Date.prototype.toJSON = function (key) {
            console.log(this.toISOString());
            return this.toISOString();
        };
    }
};
AppModule = __decorate([
    NgModule({
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
    }),
    __metadata("design:paramtypes", [])
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map