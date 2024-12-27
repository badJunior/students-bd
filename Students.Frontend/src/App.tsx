import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

import AddStudentsForm from "./AddStudentsForm";
import StudentsComponent from "./StudentsComponent";

const queryClient = new QueryClient();
function App() {



  return (
    <QueryClientProvider client={queryClient}>
      <div className="flex size-full items-center justify-center bg-slate-500 p-1">
        <div className="grid grid-rows-[auto,1fr] w-[30%] h-full gap-1">
          <div className="h-auto">
            <AddStudentsForm />
          </div>
          <div className="size-full  rounded-lg">
            <StudentsComponent />
          </div>


        </div>

      </div>
    </QueryClientProvider>

  );
}

export default App;
