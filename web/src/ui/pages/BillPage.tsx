import { useEffect, useState } from "react";

import BillTable from "../components/BillTable";
import { Bill, Client } from "../../utils/types";
import {
  billAllGetService,
  clientAllGetService,
} from "../../services/services";

const BillPage = () => {
  const [bills, setBills] = useState<Bill[]>([]);
  const [clients, setClients] = useState<Client[]>([]);

  useEffect(() => {
    (async () => {
      const dataBills = await billAllGetService();
      setBills(dataBills ?? []);
      const dataClients = await clientAllGetService();
      setClients(dataClients ?? []);
    })();
  }, []);
  return (
    <div className="w-screen h-screen bg-[#ebeff3] flex flex-col">
      <div className="border-b-2 bg-[#ebeff3] p-4 w-screen sticky top-0">
        <h1 className="text-3xl font-bold m-4">Facturas</h1>
      </div>
      <BillTable bills={bills} clients={clients} />
    </div>
  );
};

export default BillPage;
