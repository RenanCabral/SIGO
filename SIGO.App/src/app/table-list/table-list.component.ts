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
  regulatoryNormCategory: RegulatoryNormCategory[];

  constructor(private http: HttpClient) { 
    
    this.showRegulatoryNorms();
  }
  
  ngOnInit() {
  }

  getRegulatoryNorms() {
    return this.http.get('http://localhost:5000/RegulatoryNorms/GetAll');
  }

  showRegulatoryNorms()  {
    this.getRegulatoryNorms()
    .subscribe((data: RegulatoryNorm[]) => this.regulatoryNorms = data);
  }

}
