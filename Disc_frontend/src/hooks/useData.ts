import { CanceledError, type AxiosRequestConfig } from "axios";
import { useEffect, useState } from "react";
import apiClient from "../services/api-client";

//my api returns a direct array of employees, not an object with a results property
//so I changed Response to T[] and res.data.results to res.data

const useData = <T>(
  endpoint: string,
  requestConfig?: AxiosRequestConfig,
  dependencies?: unknown[],) => {
  const [data, setData] = useState<T[]>([]);
  const [error, setError] = useState("");
  const [isLoading, setIsLoading] = useState(false);
  
  useEffect(() => {
    const controller = new AbortController();
    setIsLoading(true);
    
      const url = new URL(endpoint, apiClient.defaults.baseURL);
  if (requestConfig?.params) {
    Object.entries(requestConfig.params).forEach(([key, value]) => {
      if (value !== undefined && value !== null) {
        url.searchParams.append(key, String(value));
      }
    });
  }
  console.log("Full API URL:", url.toString());
    apiClient
      .get<T[]>(endpoint, { signal: controller.signal, ...requestConfig })  
      .then((res) => {
        setData(res.data);  
        setIsLoading(false);
        console.log('res');
        console.log(res.data);
        console.log(endpoint)
      })
      .catch((err) => {
        if (err instanceof CanceledError) return;
        setError(err.message);
        console.log(err);
        setIsLoading(false);
      });
    return () => controller.abort();
  },
   dependencies ? [...dependencies] : []);
  
  return { data, error, isLoading };
  // return { data, error, isLoading };
};

export default useData;