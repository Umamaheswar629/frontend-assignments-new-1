export interface Item {
  id:          number;
  name:        string;
  category:    string;
  price:       number;
  quantity:    number;
  status:      string;   // 'In Stock' | 'Out of Stock' | 'Discontinued'
  description: string;
}