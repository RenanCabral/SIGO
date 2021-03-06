import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { RegulatoryNorm } from 'app/models/regulatory-norms/regulatory-norms.model';
import { RegulatoryNormCategory } from 'app/models/regulatory-norms/regulatory-norm-category.model';

@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrls: ['./table-list.component.css']
})
export class TableListComponent implements OnInit {
  
  regulatoryNorms: RegulatoryNorm[];
  
  regulatoryNormCategory: any[];
  
  constructor(private http: HttpClient) { 
  
    this.regulatoryNormCategory = new Array();
    this.regulatoryNormCategory[0] = 'Segurança do Trabalho';
    this.regulatoryNormCategory[1] = 'Ambiental';
    this.regulatoryNormCategory[2] = 'Industrial';

    this.getNormsUpdates();
    //this.showRegulatoryNorms();
  }
  
  ngOnInit() {
  }

  getRegulatoryNorms() {
    return this.http.get('https://regulatory-norms-api.azurewebsites.net/regulatorynorms/GetAll');
  }

  checkUpdates() {
    return this.http.get('https://regulatory-norms-api.azurewebsites.net/regulatorynorms/CheckUpdates');
  }

  showRegulatoryNorms()  {
    this.getRegulatoryNorms()
    .subscribe((data: RegulatoryNorm[]) => this.regulatoryNorms = data);
  }

  getNormsUpdates() {
    this.checkUpdates()
    .subscribe((data: any) => this.showRegulatoryNorms() );
  }

  // getNormsUpdates() {
  //   this.checkUpdates().subscribe();
  // }

}
