'use client'

import { use } from 'react'
import BookLoading from '~app/(workspace)/books/[id]/loading'

import BookOverview from '~widgets/book-overview'

import { IBook, useBook } from '~models/book'

import { RenderFetchData } from '~packages/lib'

export default function BookPage({
	params,
}: {
	params: Promise<{ id: string }>
}) {
	const { id } = use(params)
	const { isLoading, data } = useBook(id)

	return (
		<>
			<RenderFetchData
				isLoading={isLoading}
				loadingFallback={<BookLoading />}
			>
				<BookOverview book={data?.data.result as IBook} />
			</RenderFetchData>
		</>
	)
}
