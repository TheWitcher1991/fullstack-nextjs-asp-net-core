'use client'

import { use } from 'react'

import { useBook } from '~models/book'

import { BreadcrumbsTitle } from '~packages/ui'

export default function BookPage({
	params,
}: {
	params: Promise<{ id: string }>
}) {
	const { id } = use(params)
	const { isLoading, data } = useBook(id)

	return (
		<>
			<BreadcrumbsTitle title={'Книга'} />
		</>
	)
}
