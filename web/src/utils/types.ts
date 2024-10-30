export type Bill ={
  billCode: string;
  clientId?: string;
  city?: string;
  billTotal?: number;
  subtotal?: number;
  vat?: number;
  withholding?: number;
  creationDate: string;
  status?: string;
  isPaid?: boolean;
  paymentDate?: string;
}

export type Client= {
  id: string;
  name: string;
  email: string;
}