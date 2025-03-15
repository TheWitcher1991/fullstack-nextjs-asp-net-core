'use client'

import BookCreate from '~widgets/book-create'

import { BreadcrumbsTitle } from '~packages/ui'

export default function BookCreatePage() {
	return (
		<>
			<BreadcrumbsTitle title={'Новая книга'} />
			<BookCreate />
		</>
	)
}
