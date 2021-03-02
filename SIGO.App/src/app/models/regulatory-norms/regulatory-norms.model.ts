import { RegulatoryNormCategory } from "./regulatory-norm-category.model";

export class RegulatoryNorm {
    RegulatoryNormId: number;
    Code: string;
    Description: string;
    ReleaseDate: Date;
    Active: string;
    Category: RegulatoryNormCategory;
  }
  