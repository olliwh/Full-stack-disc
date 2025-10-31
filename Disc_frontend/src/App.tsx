import { useState } from "react";

import { Grid, GridItem, Show } from "@chakra-ui/react";

import DepartmentList from "./components/DepartmentList";
import EmployeeGrid from "./components/EmployeeGrid";
import { NavBar } from "./components/NavBar";
import type { Department } from "./hooks/useDepartments";

function App() {
  const [selectedDepartment, setSelectedDepartment] =
    useState<Department | null>(null);
    console.log('app tsx ' + selectedDepartment?.id)
  return (
    <Grid
      templateAreas={{ base: `"nav" "main"`, lg: `"nav nav" "aside main"` }}
    >
      <GridItem area="nav">
        <NavBar />
      </GridItem>
      <Show above="lg">
        <GridItem area="aside">
          <DepartmentList
          selectedDepartment = {selectedDepartment}
            onSelectDepartment={(department) =>
              setSelectedDepartment(department)
            }
          />
        </GridItem>
      </Show>
      <GridItem area="main">
        <EmployeeGrid selectedDepartment={selectedDepartment}/>
        hello
      </GridItem>
    </Grid>
  );
}

export default App;
