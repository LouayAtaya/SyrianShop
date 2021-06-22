import { ProductImage } from './product-image';
export class Product {
    id:	number
    title: string
    description:string
    price: number
    quantity: number
    creationDate: Date
    productImages: ProductImage[];	

}
