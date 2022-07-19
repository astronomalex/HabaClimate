export interface Good {
  id: number;
  name: string;
  shortDesc: string;
  longDesc: string;
  img: string;
  price: number;
  available: boolean;
  isFavorite: boolean;
  categoryId: number;
  categoryName: string;
  brandName: string;
}
