import { Product } from "./product";

export class ProductPaginationResult {
    pageStart: number;
    pageSize: number;	
    totalRecords: number;
    data: Product[];
}
