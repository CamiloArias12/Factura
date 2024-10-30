import { Bill, Client } from "../../utils/types";

type Props = {
  bills: Bill[];
  clients: Client[];
};

const BillTable = (props: Props) => {
  const getClientNameById = (id: string) => {
    const client = props.clients.find((client) => client.id === id);
    return client ? client.name : "N/A";
  };
  const getClientNitById = (id: string) => {
    const client = props.clients.find((client) => client.id === id);
    return client ? client.nit : "N/A";
  };
  const classNameRow = "p-2 border-b-4 ";

  return (
    <div className="m-10 overflow-auto">
      <table className="min-w-full bg-white text-sm ">
        <thead>
          <tr>
            {[
              "Codigo factura",
              "Cliente",
              "Nit",
              "Ciudad",
              "Total Factura",
              "Subtotal",
              "Iva",
              "Retencion",
              "Fecha de creacion",
              "Estado",
              "Pagada",
              "Fecha de pago",
            ].map((header) => (
              <th
                key={header}
                className="px-4 py-2 bg-white border-b-2 border-b-black font-bold text-black uppercase text-left"
              >
                {header}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {props.bills.map((bill) => (
            <tr key={bill.billCode} className="hover:bg-gray-100 ">
              <td className={classNameRow}>{bill.billCode}</td>
              <td className={classNameRow}>
                {getClientNameById(bill.clientId || "")}
              </td>
              <td className={classNameRow}>
                {getClientNitById(bill.clientId || "")}
              </td>
              <td className={classNameRow}>{bill.city || "N/A"}</td>
              <td className={classNameRow}>
                {bill.billTotal ? bill.billTotal.toFixed(2) : "N/A"}
              </td>
              <td className={classNameRow}>
                {bill.subtotal ? bill.subtotal.toFixed(2) : "N/A"}
              </td>
              <td className={classNameRow}>
                {bill.vat ? bill.vat.toFixed(2) : "N/A"}
              </td>
              <td className={classNameRow}>
                {bill.withholding ? bill.withholding.toFixed(2) : "N/A"}
              </td>
              <td className={classNameRow}>
                {new Date(bill.creationDate).toLocaleDateString()}
              </td>
              <td className={classNameRow}>{bill.status || "N/A"}</td>
              <td className={classNameRow}>{bill.isPaid ? "Si" : "No"}</td>
              <td className={classNameRow}>
                {bill.paymentDate
                  ? new Date(bill.paymentDate).toLocaleDateString()
                  : "N/A"}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BillTable;
