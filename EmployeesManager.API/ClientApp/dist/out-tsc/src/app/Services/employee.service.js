var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
let TodosService = class TodosService {
    constructor(http, baseUrl) {
        this.http = http;
        this.employees = [];
        this._baseUrl = baseUrl;
    }
    fetchTodos(callback) {
        this.http.get(this._baseUrl + 'api/Employee').subscribe(result => {
            if (result.isSuccessful) {
                this.employees = result.result;
            }
            callback();
        }, error => console.error(error));
    }
    create(employee, callback) {
        console.log(employee);
        this.http.post(this._baseUrl + 'api/Employee', employee).subscribe(result => {
            if (result.isSuccessful) {
                this.employees.push(result.result);
                callback();
            }
        }, error => console.error(error));
    }
    update(employee) {
        this.http.put(this._baseUrl + 'api/Employee', employee).subscribe(result => {
            if (result.isSuccessful) {
                this.employees.push(result.result);
            }
        }, error => console.error(error));
    }
    delete(id, callback) {
        this.http.delete(this._baseUrl + 'api/Employee/' + id, {}).subscribe(result => {
            if (result.isSuccessful) {
                this.employees = this.employees.filter(t => t.id !== id);
            }
            callback();
        }, error => console.error(error));
    }
};
TodosService = __decorate([
    Injectable({ providedIn: 'root' }),
    __param(1, Inject('BASE_URL')),
    __metadata("design:paramtypes", [HttpClient, String])
], TodosService);
export { TodosService };
//# sourceMappingURL=employee.service.js.map