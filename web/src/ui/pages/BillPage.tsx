// pages/BillPage.tsx
import  { useEffect, useState } from 'react';

import BillTable from '../components/BillTable';
import { Bill, Client } from '../../utils/types';
import { billAllGetService, clientAllGetService } from '../../services/services';

const BillPage = () => {
    const [bills, setBills] = useState<Bill[]>([])
    const [clients,setClients]=useState<Client[]>([])


    useEffect(() => {
        (async () => {
            const dataBills = await billAllGetService()
            setBills(dataBills ?? []);
            const dataClients = await clientAllGetService()
            setClients(dataClients ?? [])
    })()
},[])
  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold text-blue-700 mb-4">Bill Table</h1>
      <BillTable bills={bills} clients={clients} />
    </div>
  );
};

export default BillPage;
