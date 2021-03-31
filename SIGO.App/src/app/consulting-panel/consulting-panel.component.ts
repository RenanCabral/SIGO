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

  workSafetyNormsCount: number; 
  environmentalNormsCount: number;
  industrialNormsCount: number;

  constructor(private http: HttpClient) { 

    this.regulatoryNormCategory = new Array();
    this.regulatoryNormCategory[0] = 'Segurança do Trabalho';
    this.regulatoryNormCategory[1] = 'Ambiental';
    this.regulatoryNormCategory[2] = 'Industrial';

    this.workSafetyNormsCount = 0; 
    this.environmentalNormsCount = 0; 
    this.industrialNormsCount = 0; 

    this.updatedNorms = new Array();
    this.showNormsUpdates();
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

  readRegulatoryNorms (retulatoryNorms : RegulatoryNorm[])
  {
    this.updatedNorms = retulatoryNorms;
    
    this.workSafetyNormsCount = this.updatedNorms.filter(x => x.Category.toString() == 'WorkSafety').length;
    this.environmentalNormsCount = this.updatedNorms.filter(x => x.Category.toString() == 'Environmental').length;
    this.industrialNormsCount = this.updatedNorms.filter(x => x.Category.toString() == 'Industrial').length;
  }

  showNormsNotifcations() {

  }

}
