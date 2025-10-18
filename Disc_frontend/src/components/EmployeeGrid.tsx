
import { SimpleGrid, Text } from "@chakra-ui/react";
import useEmployees from "../hooks/useEmployees";
import EmployeeCard from "./EmployeeCard";

  

const EmployeeGrid = () => {

  const {employees, error} = useEmployees();
  return (
    <div>
      {error && <Text color="tomato">{error}</Text>}
      <SimpleGrid
        columns={{ sm: 1, md: 2, lg: 3, xl: 5 }}
        spacing={10}//space between cards
        padding="10"//space to sides
        >
        {employees?.map((employee) => (
          <EmployeeCard key={employee.id} employee={employee} />
        ))}
      </SimpleGrid>
    </div>
  );
};
export default EmployeeGrid;
