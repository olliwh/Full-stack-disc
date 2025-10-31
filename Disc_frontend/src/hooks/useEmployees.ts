import type { EmployeeQuery } from "../App";
import useData from "./useData";
import type { DiscProfile } from "./useDiscProfiles";

export interface Employee {
  id: number;
  email: string;
  phone: string;
  firstName: string;
  lastName: string;
  experience: number;
  imagePath: string;
  companyId: number;
  discType: DiscProfile;
}

const useEmployees = (employeeQuery: EmployeeQuery) =>
  useData<Employee>(
    "/employees",
    {
      params: {
        departmentId: employeeQuery.department?.id,
        positionId: employeeQuery.position?.id,
        discProfileId: employeeQuery.discProfile?.id,
      },
    },
    [employeeQuery],
  );
export default useEmployees;
