import { QueryClientProvider } from '@tanstack/react-query'
import { ReactQueryDevtools } from '@tanstack/react-query-devtools'
import { PropsWithChildren } from 'react'

import { queryClient } from '~packages/lib'
import { IS_DEV } from '~packages/system'

const WithReactQuery = ({ children }: PropsWithChildren) => {
	return (
		<QueryClientProvider client={queryClient}>
			<>{children}</>
			{IS_DEV && <ReactQueryDevtools initialIsOpen={false} />}
		</QueryClientProvider>
	)
}

export default WithReactQuery
