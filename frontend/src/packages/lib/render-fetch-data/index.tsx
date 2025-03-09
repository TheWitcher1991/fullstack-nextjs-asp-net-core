import { PropsWithChildren, ReactNode } from 'react'

interface RenderFetchDataProps extends PropsWithChildren {
	isLoading: boolean
	hasError?: boolean
	countData?: number | string
	loadingFallback?: ReactNode
	errorFallback?: ReactNode
	emptyFallback?: ReactNode
}

const DefaultLoadingFallback = () => <div>Загрузка...</div>
const DefaultErrorFallback = () => <div>Произошла ошибка</div>
const DefaultEmptyFallback = () => <div>Нет данных</div>

export const RenderFetchData = ({
	isLoading,
	hasError = false,
	countData,
	children,
	loadingFallback = <DefaultLoadingFallback />,
	errorFallback = <DefaultErrorFallback />,
	emptyFallback = <DefaultEmptyFallback />,
}: RenderFetchDataProps) => {
	if (isLoading) {
		return <>{loadingFallback}</>
	}

	if (hasError) {
		return <>{errorFallback}</>
	}

	if (countData !== undefined && Number(countData) === 0) {
		return <>{emptyFallback}</>
	}

	return <>{children}</>
}
