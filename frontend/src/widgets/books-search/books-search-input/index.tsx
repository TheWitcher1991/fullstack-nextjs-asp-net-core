import { Magnifier } from '@gravity-ui/icons'
import { Icon, TextInput } from '@gravity-ui/uikit'

import { useBooksSearchStore } from '~widgets/books-search/books-search.store'

import { useDebounce } from '~packages/hooks'

export default function BooksSearchInput() {
	const { setFilter, loading } = useBooksSearchStore()

	const onSearch = useDebounce((e: any) => {
		setFilter({
			search: e.target.value,
		})
	})

	return (
		<TextInput
			placeholder={'Книги, авторы, жанры...'}
			size={'xl'}
			onChange={onSearch}
			disabled={loading}
			startContent={
				<div style={{ marginInline: 6 }}>
					<Icon data={Magnifier} size={18} />
				</div>
			}
		/>
	)
}
