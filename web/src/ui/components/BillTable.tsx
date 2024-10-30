import { Bill, Client } from '../../utils/types';

type Props = {
    bills: Bill[]
    clients:Client[]
}

const BillTable = (props:Props) => {
  const getClientNameById = (id:string) => {
    const client = props.clients.find(client => client.id === id);
    return client ? client.name : 'N/A';
  };

  return (
    <div className="overflow-x-auto">
      <table className="min-w-full bg-white border border-gray-300">
        <thead>
          <tr>
            {[
              'Codigo factura', 'Cliente', 'City', 'Total Factura', 'Subtotal', 'Iva',
              'Retencion', 'Fecha de creacion', 'Estado', 'Pagada', 'Fecha de pago'
            ].map((header) => (
              <th
                key={header}
                className="px-4 py-2 bg-blue-100 border-b font-bold text-blue-600 text-left"
              >
                {header}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {props.bills.map((bill) => (
            <tr key={bill.billCode} className="hover:bg-gray-100">
              <td className="px-4 py-2 border-b font-bold text-blue-600">{bill.billCode}</td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">
                {getClientNameById(bill.clientId || '')}
              </td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">{bill.city || 'N/A'}</td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">
                {bill.billTotal ? bill.billTotal.toFixed(2) : 'N/A'}
              </td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">
                {bill.subtotal ? bill.subtotal.toFixed(2) : 'N/A'}
              </td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">
                {bill.vat ? bill.vat.toFixed(2) : 'N/A'}
              </td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">
                {bill.withholding ? bill.withholding.toFixed(2) : 'N/A'}
              </td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">
                {new Date(bill.creationDate).toLocaleDateString()}
              </td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">{bill.status || 'N/A'}</td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">
                {bill.isPaid ? 'Si' : 'No'}
              </td>
              <td className="px-4 py-2 border-b font-bold text-blue-600">
                {bill.paymentDate ? new Date(bill.paymentDate).toLocaleDateString() : 'N/A'}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BillTable;
