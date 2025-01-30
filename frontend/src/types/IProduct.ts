import { INutritionalDetails } from "./INutritionalDetails";

export interface IProduct {
  id: number;
  productName: string;
  customText: string;
  weight: string;
  warning: string;
  ingredients: string;
  productContains: string;
  productDoesNotContain: string;
  category: string;
  nutritionalDetails: INutritionalDetails;
}
