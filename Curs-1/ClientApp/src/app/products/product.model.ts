export class Product {
  id: number;
  name: string;
  description: string;
  price: number;
}

export class PaginatedProducts {
  firstPages: number[];
  lastPages: number[];
  previousPages: number[];
  nextPages: number[];
  totalEntities: number;
  entities: Product[];
}