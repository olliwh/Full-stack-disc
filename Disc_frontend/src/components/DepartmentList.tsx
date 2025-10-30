import { Spinner, Text } from "@chakra-ui/react";

import useData from "../hooks/useData";
import type { Department } from "../hooks/useDepartments";

const DepartmentList = () => {
  const {
    data: departments,
    error,
    isLoading,
  } = useData<Department>("/departments");
  if (error) return null;

  if (isLoading) return <Spinner />;
  return (
    <>
      {departments.map((genre) => (
        <Text key={genre.id}>{genre.name}</Text>
      ))}
    </>
  );
};
export default DepartmentList;
