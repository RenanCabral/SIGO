import { Component, OnInit } from '@angular/core';
import { RegulatoryNorm } from 'app/models/regulatory-norms/regulatory-norms.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-consulting-panel',
  templateUrl: './consulting-panel.component.html',
  styleUrls: ['./consulting-panel.component.css']
})
export class ConsultingPanelComponent implements OnInit {

  updatedNorms: RegulatoryNorm[];
  regulatoryNormCategory: any[];

  workSafetyNorms: any[]; 
  environmentalNorms: any[]; 
  industrialNorms: any[]; 

  constructor(private http: HttpClient) { 

    this.regulatoryNormCategory = new Array();
    this.regulatoryNormCategory['WorkSafety'] = 'Segurança do Trabalho';
    this.regulatoryNormCategory['Environmental'] = 'Ambiental';
    this.regulatoryNormCategory['Industrial'] = 'Industrial';

    this.workSafetyNorms = new Array(); 
    this.environmentalNorms = new Array(); 
    this.industrialNorms = new Array(); 

    this.updatedNorms = new Array();
    
    this.checkUpdates();
  }

  ngOnInit(): void {
  }

  getNormsUpdates() {
    return this.http.get('http://localhost:5001/Consulting/GetNormsUpdates');
  }

  showNormsUpdates()  {
    this.getNormsUpdates()
    .subscribe((data: RegulatoryNorm[]) => this.readRegulatoryNorms(data));
  }

  readRegulatoryNorms (retulatoryNorms : any[])
  {
    this.updatedNorms = retulatoryNorms
  
    this.workSafetyNorms = retulatoryNorms.filter(x => x.category == 'WorkSafety');
    this.environmentalNorms = retulatoryNorms.filter(x => x.category == 'Environmental');
    this.industrialNorms = retulatoryNorms.filter(x => x.category == 'Industrial');
  }

  showNormsNotifcations (category : string) {

    if (category === 'WorkSafety') {
      this.updatedNorms = this.workSafetyNorms;
    }

    if (category === 'Environmental') {
      this.updatedNorms = this.environmentalNorms;
    }

    if (category === 'Industrial') {
      this.updatedNorms = this.industrialNorms;
    }

  }

  newContract() {
    window.location.href = '#/consulting';
  }

  checkUpdates() {
    this.checkNormsUpdates()
    .subscribe((data: any) => this.showNormsUpdates());
  }

  checkNormsUpdates() {
    return this.http.get('http://localhost:5000/RegulatoryNorms/CheckUpdates');
  }
}
